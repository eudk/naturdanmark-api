namespace naturdanmark_api.Repositories;
using naturdanmark_api.Models;
using Context;

public class ImageRepo
{

    private readonly ObservationContext context;

    public ImageRepo(ObservationContext dbcontext)
    {
        context = dbcontext;
    }

    /// <summary>
    /// Add an image to the DB
    /// </summary>
    /// <param name="img">Represents an image</param>
    /// <returns> Returns the added image object</returns>
    public Image Add(Image img)
    {
        if(img == null)
        {
            throw new ArgumentNullException(nameof(img));
        }
        img.validate();
        img.OberservationID = context.Observaitonfotos.Count() + 1;
        context.Observaitonfotos.Add(img);
        context.SaveChanges();
        return img;
    }

    /// <summary>
    /// Fetch an image given id
    /// </summary>
    /// <param name="id">Id of the image to fetch</param>
    /// <returns>Returns Image of id, or null if not found</returns>
    public Image? GetById(int id)
    {
        return context.Observaitonfotos.FirstOrDefault(i => i.OberservationID == id);
    }

    public int Count()
    {
        return context.Observaitonfotos.Count();
    }
}
