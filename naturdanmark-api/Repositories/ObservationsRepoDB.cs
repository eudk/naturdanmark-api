namespace naturdanmark_api.Repositories;
using naturdanmark_api.Models;
using naturdanmark_api.Repositories;
using Context;
using System.Numerics;

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
        obs.PostingDate = DateTime.Now;
        context.Observations.Add(obs);
        context.SaveChanges();
        return obs;
    }

    /// <summary>
    /// Laver en liste af observationer ud fra Observationstabellen i databasen
    /// </summary>
    /// <returns>returnere en liste af observationer eller en tom liste</returns>
    public List<Observation> Get(bool ofToday = false, string? SortByDate = null, string? AnimalName = null, double? longitude = null, double? latitude = null, int amount = int.MaxValue)
    {
        List<Observation> observations = new List<Observation>(context.Observations);
        if (ofToday)
        {
            observations = observations.Where(a => a.Date >= DateTime.Now.AddHours(-24)).ToList();
        }
        if(SortByDate != null)
        {
            SortByDate = SortByDate.ToLower();
            observations = SortByDate switch
            {
                "dateasc" => observations.OrderBy(a => a.Date).ToList(),
                "datedesc" => observations.OrderByDescending(a => a.Date).ToList(),
                "distance" => observations.OrderBy(a => a.DistanceFrom(latitude, longitude)).ToList(),
                _ => throw new ArgumentException("Invalid SortBy method.")

            };
        }
        if (AnimalName != null)
        {
            observations = observations.Where(a => a.AnimalName.Contains(AnimalName, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }
        return observations.Take(amount).ToList();
    }

    /// <summary>
    /// Finder en specifik Observation i databasen ud fra id
    /// </summary>
    /// <param name="id">Et id som skal eksistere i observationsdatabasen for at hente en observation</param>
    /// <returns>returnere en observation eller Null</returns>
    public Observation? Getbyid(int id)
    {
        return context.Observations.FirstOrDefault(i => i.ID == id);
    }

    
}
