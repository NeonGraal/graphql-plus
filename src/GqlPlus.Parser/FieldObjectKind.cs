using GqlPlus.Abstractions.Schema;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public class FieldObjectKind<TObjField>(TypeKind kind)
  : IGqlpFieldKind<TObjField>
  where TObjField : IGqlpObjField
{
  public TypeKind FieldKind { get; } = kind;
}

public static class FieldObjectKinds
{
  public static IServiceCollection AddFieldObjectKinds(this IServiceCollection services)
    => services
      .AddSingleton<IGqlpFieldKind<IGqlpDualField>>(new FieldObjectKind<IGqlpDualField>(TypeKind.Dual))
      .AddSingleton<IGqlpFieldKind<IGqlpInputField>>(new FieldObjectKind<IGqlpInputField>(TypeKind.Input))
      .AddSingleton<IGqlpFieldKind<IGqlpOutputField>>(new FieldObjectKind<IGqlpOutputField>(TypeKind.Output));
}
