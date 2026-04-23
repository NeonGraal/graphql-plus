namespace GqlPlus.Building;

public class ModifierBuilder
  : ErrorBuilder
{
  private readonly ModifierKind _kind;
  private readonly string _key;

  public ModifierBuilder(ModifierKind kind, string key = "")
  {
    Add<IAstModifier>();
    _kind = kind;
    _key = key;
  }

  protected new T Build<T>()
    where T : class, IAstModifier
  {
    T result = base.Build<T>();
    result.ModifierKind.Returns(_kind);
    result.Key.Returns(_key);
    return result;
  }

  public IAstModifier AsModifier
    => Build<IAstModifier>();
}

public interface IModifiersBuilder
  : IMockBuilder
{
  void SetModifiers(params IAstModifier[] modifiers);
}

public static class ModifierBuilderHelper
{
  public static T WithModifier<T>(this T builder, ModifierKind kind, string key = "")
    where T : IModifiersBuilder
    => builder.WithModifiers(builder.Modifier(kind, key));
  public static T WithModifiers<T>(this T builder, params IAstModifier[] modifiers)
    where T : IModifiersBuilder
    => builder.FluentAction(b => b.SetModifiers(modifiers));
}
