using AutoMapper;
using BitrateCalculator.Data;
using BitrateCalculator.Models;
using BitrateCalculator.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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

    public Transcoder UploadVideo(string json)
    {
        //parsing the JSON
        var data = JsonConvert.DeserializeObject<Transcoder>(json);

        foreach (var nic in data.NIC)
        {
            nic.Rx = BitrateCalculator(nic.Rx); //receiving (Rx)
            nic.Tx = BitrateCalculator(nic.Tx); //transmitting (Tx)
        }

        _context.Transcoder.Add(data);
        _context.SaveChanges();

        var returnData = _mapper.Map<Transcoder>(data);

        return returnData;

        throw new NotImplementedException();
    }

    public long BitrateCalculator(long bits)
    {
        //Number of Bits per Data Point (Rx) = Rx Bitrate / 2
        //Number of Bits per Data Point (Tx) = Tx Bitrate / 2
        return bits = bits / 2; 
    }
}
