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

    public Observation Add(Observation obs)
    {
        obs.ID = 0;
        context.Observations.Add(obs);
        context.SaveChanges();
        return obs;
    }

    public List<Observation> GetAll()
    {
        return new List<Observation>(context.Observations);
    }

    public Observation? Getbyid(int id)
    {
        return context.Observations.FirstOrDefault(i => i.ID == id);
    }
}
