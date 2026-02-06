using System.ComponentModel.DataAnnotations;

namespace ProductManager.Dtos;

public record class InsertImageDto([Required] string Content, int ProductId);
