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
            nic.Rx = nic.Rx * 8 / 2; //2 Hz
            nic.Tx = nic.Tx * 8 / 2;
        }

        _context.Transcoder.Add(data);
        _context.SaveChanges();

        var returnData = _mapper.Map<Transcoder>(data);

        return returnData;

        throw new NotImplementedException();
    }
}
