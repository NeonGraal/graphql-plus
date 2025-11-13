using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public abstract class InputFieldTypeTests<TInput>
  : ObjFieldTypeTests<TInput>
{
  [Theory, RepeatData]
  public void HashCode_WithDefault(TInput input, string def)
      => InputFieldChecks.HashCode_WithDefault(input, def);

  [Theory, RepeatData]
  public void String_WithDefault(TInput input, string def)
    => InputFieldChecks.String_WithDefault(input, def);

  [Theory, RepeatData]
  public void Equality_WithDefault(TInput input, string def)
    => InputFieldChecks.Equality_WithDefault(input, def);

  [Theory, RepeatData]
  public void Inequality_BetweenDefaults(TInput input, string def1, string def2)
    => InputFieldChecks.Inequality_BetweenDefaults(input, def1, def2);

  internal abstract IInputFieldTypeChecks<TInput> InputFieldChecks { get; }
  internal sealed override IObjFieldTypeChecks<TInput> FieldChecks => InputFieldChecks;
}

internal abstract class InputFieldTypeChecks<TInput, TObjType>(
  ObjFieldTypeChecks<TInput, TObjType>.TypeBy createType,
  BaseAstChecks<TObjType>.CloneBy<TInput> cloneInput
) : ObjFieldTypeChecks<TInput, TObjType>(createType, cloneInput)
  , IInputFieldTypeChecks<TInput>
  where TObjType : IGqlpInputFieldType
  where TInput : ITypeInput
{
  public void HashCode_WithDefault(TInput input, string def)
      => HashCode(() => WithDefault(CreateInput(input), def));
  public void String_WithDefault(TInput input, string def)
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
  void String_WithDefault(TInput input, string def);
  void Equality_WithDefault(TInput input, string def);
  void Inequality_BetweenDefaults(TInput input, string def1, string def2);
}
