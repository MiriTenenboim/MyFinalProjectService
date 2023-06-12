using AutoMapper;
using AutoMapper.Configuration.Conventions;
using SpurringSportActivity.Common.DTO;
using SpurringSportActivity.Repositories.Entities;
using SpurringSportActivity.Repositories.Interfaces;
using SpurringSportActivity.Services.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Services.Services
{
    public class PointDetailsService : IPointDetailsService
    {
        private readonly IPointDetailsRepository _pointDetailsRepository;
        private readonly IPublicPointService _publicPointService;
        private readonly IMapper _mapper;

        private static ConcurrentDictionary<int, Task<PublicPointDTO>> timers = new ConcurrentDictionary<int, Task<PublicPointDTO>>();
        int totalSeconds;
        private bool stopTimer;

        public PointDetailsService(IPointDetailsRepository pointDetailsRepository, IPublicPointService publicPointService, IMapper mapper)
        {
            _pointDetailsRepository = pointDetailsRepository;
            _publicPointService = publicPointService;
            _mapper = mapper;
        }

        public bool StartTimer(DateTime date, int pointId, int userId)
        {
            int timerId = userId;

            totalSeconds = CalculateDifferenceInSeconds(DateTime.Today, date);

            Task<PublicPointDTO> timerTask = StartTimerAsync(timerId, pointId);

            timers.TryAdd(timerId, timerTask);

            var pointDetails = GetPointByPointIdAsync(0, userId).Result;

            Task.Run(() => CheckVariableChange(timerId, pointDetails));

            return true;
        }

        // חישוב הפרש בשניות בין תאריכים
        private int CalculateDifferenceInSeconds(DateTime date1, DateTime date2)
        {
            TimeSpan timeSpan = date2 - date1;
            int differenceInSeconds = (int)timeSpan.TotalSeconds;
            return differenceInSeconds;
        }


        private async Task<PublicPointDTO> StartTimerAsync(int timerId, int pointId)
        {
            await Task.Delay(totalSeconds);
            if (stopTimer)
            {
                timers.TryRemove(timerId, out _);
                return null;
            }
            var publicPoint = new PublicPointDTO(pointId);
            // אם הנקודה עדיין לא מומשה ועבר למשתמש הזמן נוסיף את הנקודה לטבלת נקודות ציבוריות
            return await _publicPointService.AddPublicPointAsync(publicPoint);
        }

        private void CheckVariableChange(int timerId, PointDetailsDTO pointDetails)
        {
            while (!stopTimer)
            {
                if (VariableHasChanged(pointDetails))
                {
                    stopTimer = true;

                    timers.TryRemove(timerId, out _);
                }
                Thread.Sleep(1000);
            }
        }

        private bool VariableHasChanged(PointDetailsDTO pointDetails)
        {
            if (pointDetails.IsRealized == true)
            {
                return true;
            }
            return false;
        }

        public async Task<PointDetailsDTO> AddPointDetailsAsync(PointDetailsDTO pointDetails)
        {
            if (pointDetails.UserOrCompany == Common.DTO.EStatus.User)
            {
                pointDetails.PlacingDate = DateTime.Now;
                // נשלח את הערך ברירת מחדל
                pointDetails.CompanyPointId = 1;
            }
            else
            {
                pointDetails.PlacingDate = DateTime.Now;
                // נשלח את הערך ברירת מחדל
                pointDetails.UserPointId = 1;
            }
            pointDetails.WinningUserId = 1;
            var newPointDetails = _mapper.Map<PointDetailsDTO>(await _pointDetailsRepository.AddPointDetailsAsync(_mapper.Map<PointsDetails>(pointDetails)));
            if (pointDetails.UserOrCompany == Common.DTO.EStatus.Company)
            {
                // אם הנקודה שייכת לחברה נוסיף אותה לטבלת הנקודות הציבוריות
                var newPublicPoint = new PublicPointDTO(newPointDetails.PointId);
                await _publicPointService.AddPublicPointAsync(newPublicPoint);
            }
            else
            {
                // אם הנקודה שייכת למשתמש נפעיל טיימר שיפעל מהתאריך של היום עד לתאריך היעד של הנקודה או עד שהנקודה ממומשת
                StartTimer(newPointDetails.UserPoint.DueDate, newPointDetails.UserPointId, newPointDetails.UserPoint.UserId);
            }
            return newPointDetails;
        }

        public async Task<PointDetailsDTO> UpdateRealizedPointAsync(int id, int userId)
        {
            return _mapper.Map<PointDetailsDTO>(await _pointDetailsRepository.UpdateRealizedPointAsync(id, userId));
        }

        public async Task<List<PointDetailsDTO>> GetRealizedPointsAsync(int id)
        {
            return _mapper.Map<List<PointDetailsDTO>>(await _pointDetailsRepository.GetRealizedPointsAsync(id));
        }

        public async Task<List<PointDetailsDTO>> GetAllPointsAsync()
        {
            return _mapper.Map<List<PointDetailsDTO>>(await _pointDetailsRepository.GetAllPointsAsync());
        }

        public async Task<List<PointDetailsDTO>> GetPointsByIdAsync(int userOrCompany, int id)
        {
            return _mapper.Map<List<PointDetailsDTO>>(await _pointDetailsRepository.GetPointsByIdAsync(userOrCompany, id));
        }

        public async Task<PointDetailsDTO> GetPointByPointIdAsync(int userOrCompany, int pointId)
        {
            return _mapper.Map<PointDetailsDTO>(await _pointDetailsRepository.GetPointByPointIdAsync(userOrCompany, pointId));
        }

        public async Task<PointDetailsDTO> UpdatePointAsync(PointDetailsDTO pointDetails)
        {
            return _mapper.Map<PointDetailsDTO>(await _pointDetailsRepository.UpdatePointAsync(_mapper.Map<PointsDetails>(pointDetails)));
        }

        public async Task<PointDetailsDTO> DeletePointAsync(PointDetailsDTO pointDetails)
        {
            return _mapper.Map<PointDetailsDTO>(await _pointDetailsRepository.DeletePointAsync(_mapper.Map<PointsDetails>(pointDetails)));
        }
    }
}
