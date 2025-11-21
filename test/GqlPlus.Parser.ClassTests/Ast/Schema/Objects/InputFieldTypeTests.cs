using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

internal abstract class InputFieldTypeChecks<TInput, TObjType>(
  TypeBy<TInput, TObjType> createType
) : ObjFieldTypeChecks<TInput, TObjType>(createType)
  , IInputFieldTypeChecks<TInput>
  where TObjType : IGqlpInputFieldType
  where TInput : ITypeInput
{
  public void HashCode_WithDefault(TInput input, string def)
      => HashCode(() => WithDefault(CreateInput(input), def));
  public void Text_WithDefault(TInput input, string def)
    => Text(() => WithDefault(CreateInput(input), def), DefaultString(input, def));
  public void Equality_WithDefault(TInput input, string def)
    => Equality(() => WithDefault(CreateInput(input), def));
  public void Inequality_BetweenDefaults(TInput input, string def1, string def2)
    => InequalityBetween(def1, def2,
      def => WithDefault(CreateInput(input), def),
      def1 == def2);

  protected abstract TObjType WithDefault(TObjType objType, string def);
  protected abstract string DefaultString(TInput input, string def);
}

internal interface IInputFieldTypeChecks<TInput>
  : IObjFieldTypeChecks<TInput>
{
  void HashCode_WithDefault(TInput input, string def);
  void Text_WithDefault(TInput input, string def);
  void Equality_WithDefault(TInput input, string def);
  void Inequality_BetweenDefaults(TInput input, string def1, string def2);
}
