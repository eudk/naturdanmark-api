namespace naturdanmark_api.Repositories;
using naturdanmark_api.Models;

public class ObservationsRepo
{
    private List<Observation> Observations = new();

    private int _idcounter=1;

    public ObservationsRepo()
    {
        Observations.Add(new Observation { AnimalName = "animal", ID = _idcounter++, Picture = null, Date = DateTime.Now, Description = "A", lattitudes = 0, longtitudes = 0 });
        Observations.Add(new Observation { AnimalName = "animal", ID = _idcounter++, Picture = null, Date = DateTime.Now, Description = null, lattitudes = 0, longtitudes = 0 });
        Observations.Add(new Observation { AnimalName = "animal", ID = _idcounter++, Picture = null, Date = DateTime.Now, Description = null, lattitudes = 0, longtitudes = 0 });

    }

    public Observation Add(Observation obs)
    {
        obs.ID=_idcounter++;
        Observations.Add(obs);
        return obs;
    }

    public List<Observation> GetAll()
    {
        return new List<Observation>(Observations);
    }

    public Observation? Getbyid(int id)
    {
        return Observations.FirstOrDefault(i => i.ID == id);
    }
}
