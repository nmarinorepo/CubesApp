using Cubes.Application.Interfaces;
using Cubes.Domain.Entities;
using Cubes.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Cubes.Application.Services
{
    public class CubeService : ICubeService
    {     

        private readonly ILogger<CubeService> _log;
        private readonly IValidationService _validationService;
        private readonly ICubesCollidationService _cubesCollidationService;
        private readonly IRepository<ResponseEntity> _repository;

        public CubeService(ILogger<CubeService> log, IValidationService validationService, ICubesCollidationService cubesCollidationService, IRepository<ResponseEntity> repository)
        {
            _log = log;
            _validationService = validationService;
            _cubesCollidationService = cubesCollidationService;
            _repository = repository;
        }

        public async void Run()
        {
            string[] answer = new string[2];
            for (int i = 0; i < answer.Length; i++)
            {
                Console.Write($"Please enter center coordinates and length of cube {i+1}: ");
                answer[i] = Console.ReadLine();
            }

            if (_validationService.AreInputDataValid(answer))
            {
                Response result = await _cubesCollidationService.getIntersectingCubesVolume(answer);
                if (result.areCubesCollident)
                {                  

                    Console.WriteLine($"Cubes are collident with intersected volume = {result.volume}");
                }
                else
                {
                    Console.WriteLine("Cubes are not collident");
                }
                ResponseEntity responseEntity = new ResponseEntity() { cubesData = answer.ToList(), areCollident = result.areCubesCollident, volume = result.volume };
                _repository.Save(responseEntity);
            }
            else
            {
                _log.LogInformation("Input data no valid");
                Console.WriteLine("Input data no valid. The correct format is: number,number,number,number");
            }
        }
    }
}
