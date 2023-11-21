using AutoMapper;
using BitrateCalculator.Data;
using BitrateCalculator.Models;
using BitrateCalculator.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace BitrateCalculator.Services;

public class Bitrate : IBitrate
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public Bitrate(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Transcoder> GetAll()
    {
        var data = _context.Transcoder.Include(x => x.NIC).ToList();

        var returnData = _mapper.Map<IEnumerable<Transcoder>>(data);
        return returnData;
    }

    public Transcoder AddVideo(string json)
    {
        //    var data = JsonConvert.DeserializeObject<Video>(json);

        //    int poolingRate = 2; // Hz
        //    foreach (var nic in data.NIC)
        //    {
        //        nic.Rx = nic.Rx * 8 / poolingRate;
        //        nic.Tx = nic.Tx * 8 / poolingRate;
        //    }

        //    _context.Videos.Add(data);
        //    _context.SaveChanges();

        //    var returnData = _mapper.Map<VideoDto>(data);

        //    return returnData;

        throw new NotImplementedException();
    }
}
