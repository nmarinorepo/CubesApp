namespace Cubes.Application.Interfaces
{
    public interface ICubesCollidationService
    {
        Task<Response> getIntersectingCubesVolume(string[] input);
    }
}
