using BitrateCalculator.Models;

namespace BitrateCalculator.Services.Interface;

public interface IBitrate
{
    public IEnumerable<Transcoder> GetAll();
    Transcoder AddVideo(string json);
}
