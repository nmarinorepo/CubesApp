namespace Cubes.Domain.Entities
{
    public class ResponseEntity
    {
        public List<string> cubesData { get; set; }
        public bool areCollident { get; set; }
        public float volume { get; set; }
    }
}
