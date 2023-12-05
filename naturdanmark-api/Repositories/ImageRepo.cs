namespace naturdanmark_api.Repositories;
using naturdanmark_api.Models;
using Context;

public class ImageRepo
{

    private readonly ImageContext context;

    public ImageRepo(ImageContext dbcontext)
    {
        context = dbcontext;
    }

    /// <summary>
    /// Add an image to the DB
    /// </summary>
    /// <param name="img">Represents an image</param>
    /// <returns> returnere en observation</returns>
    public Image Add(Image img)
    {
        img.validate();
        context.Images.Add(img);
        context.SaveChanges();
        return img;
    }

    /// <summary>
    /// Fetch an image given id
    /// </summary>
    /// <param name="id">Id of the image to fetch</param>
    /// <returns>returnere en observation eller Null</returns>
    public Image? Getbyid(int id)
    {
        return context.Images.FirstOrDefault(i => i.ObservationID == id);
    }


}
