namespace GqlPlus.Schema;

public static class ConfigureSchEncoders
{
  public static IEncoderRepositoryBuilder AddSchEncoders(this IEncoderRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddSch__GlobalEncoders()
      .AddSch__ObjectEncoders()
      .AddSch__SchemaEncoders()
      .AddSch__SimpleEncoders()
      .AddSch__TypeEncoders();
}
