namespace naturdanmark_api.Repositories;
using naturdanmark_api.Models;
using Context;

public class ObservationsRepoDB
{

    private readonly ObservationContext context;

    public ObservationsRepoDB(ObservationContext dbcontext)
    {
        context = dbcontext;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obs"></param>
    /// <returns></returns>
    public Observation Add(Observation obs)
    {
        obs.ValidateAll();
        obs.ID = 0;
        context.Observations.Add(obs);
        context.SaveChanges();
        return obs;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<Observation> GetAll()
    {
        return new List<Observation>(context.Observations);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Observation? Getbyid(int id)
    {
        return context.Observations.FirstOrDefault(i => i.ID == id);
    }
}
