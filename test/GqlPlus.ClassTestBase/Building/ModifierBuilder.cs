namespace GqlPlus.Building;

public class ModifierBuilder
  : ErrorBuilder
{
  private readonly ModifierKind _kind;
  private readonly string _key;

  public ModifierBuilder(ModifierKind kind, string key = "")
  {
    Add<IGqlpModifier>();
    _kind = kind;
    _key = key;
  }

  protected new T Build<T>()
    where T : class, IGqlpModifier
  {
    T result = base.Build<T>();
    result.ModifierKind.Returns(_kind);
    result.Key.Returns(_key);
    return result;
  }

  public IGqlpModifier AsModifier
    => Build<IGqlpModifier>();
}

public interface IModifiersBuilder
  : IMockBuilder
{
  void SetModifiers(params IGqlpModifier[] modifiers);
}

public static class ModifierBuilderHelper
{
  public static T WithModifier<T>(this T builder, ModifierKind kind, string key = "")
    where T : IModifiersBuilder
    => builder.WithModifiers(builder.Modifier(kind, key));
  public static T WithModifiers<T>(this T builder, params IGqlpModifier[] modifiers)
    where T : IModifiersBuilder
    => builder.FluentAction(b => b.SetModifiers(modifiers));
}
