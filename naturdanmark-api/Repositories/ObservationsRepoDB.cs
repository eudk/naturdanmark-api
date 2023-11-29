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
    /// Tilføjer en observation til databasen
    /// </summary>
    /// <param name="obs">indeholder den observation som skal tilføjes til Observations Databasen</param>
    /// <returns> returnere en observation</returns>
    public Observation Add(Observation obs)
    {
        obs.ValidateAll();
        obs.ID = 0;
        context.Observations.Add(obs);
        context.SaveChanges();
        return obs;
    }

    /// <summary>
    /// Laver en liste af observationer ud fra Observationstabellen i databasen
    /// </summary>
    /// <returns>returnere en liste af observationer eller en tom liste</returns>
    public List<Observation> GetAll()
    {
        return new List<Observation>(context.Observations);
    }

    /// <summary>
    /// Finder en specifik Observation i databasen
    /// </summary>
    /// <param name="id">Et id som skal eksistere i observationsdatabasen for at hente en observation</param>
    /// <returns>returnere en observation eller Null</returns>
    public Observation? Getbyid(int id)
    {
        return context.Observations.FirstOrDefault(i => i.ID == id);
    }
}
