namespace naturdanmark_api.Repositories;
using naturdanmark_api.Models;
using Context;

public class ImageRepo
{

    private readonly ObservationContext context;
    private int size;

    public ImageRepo(ObservationContext dbcontext)
    {
        context = dbcontext;
        size = 0;
    }

    /// <summary>
    /// Add an image to the DB
    /// </summary>
    /// <param name="img">Represents an image</param>
    /// <returns> Returns the added image object</returns>
    public Image Add(Image img)
    {
        img.validate();
        context.Observationfotos.Add(img);
        context.SaveChanges();
        size++;
        return img;
    }

    /// <summary>
    /// Fetch an image given id
    /// </summary>
    /// <param name="id">Id of the image to fetch</param>
    /// <returns>Returns Image of id, or null if not found</returns>
    public Image? GetById(int id)
    {
        return context.Observationfotos.FirstOrDefault(i => i.ObservationID == id);
    }

    public int Count()
    {
        return size;
    }
}
