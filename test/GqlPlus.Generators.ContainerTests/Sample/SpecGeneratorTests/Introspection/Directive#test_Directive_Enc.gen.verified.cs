//HintName: test_Directive_Enc.gen.cs
// Generated from {CurrentDirectory}Directive.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Directive;

internal class test_DirectivesEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DirectivesObject>
{
  private readonly IEncoder<Itest_AndTypeObject> _itest_AndType = encoders.EncoderFor<Itest_AndTypeObject>();
  private readonly IEncoder<Itest_Directive> _itest_Directive = encoders.EncoderFor<Itest_Directive>();
  public Structured Encode(Itest_DirectivesObject input)
    => _itest_AndType.Encode(input)
      .AddEncoded("directive", input.Directive, _itest_Directive);

  internal static test_DirectivesEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_DirectiveEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DirectiveObject>
{
  private readonly IEncoder<Itest_AliasedObject> _itest_Aliased = encoders.EncoderFor<Itest_AliasedObject>();
  private readonly IEncoder<Itest_InputFieldType> _itest_InputFieldType = encoders.EncoderFor<Itest_InputFieldType>();
  public Structured Encode(Itest_DirectiveObject input)
    => _itest_Aliased.Encode(input)
      .AddEncoded("parameter", input.Parameter, _itest_InputFieldType)
      .Add("repeatable", input.Repeatable.Encode());

  internal static test_DirectiveEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_LocationEncoder : IEncoder<test_Location>
{
  public Structured Encode(test_Location input)
    => input.EncodeEnum("_Location");

  internal static test_LocationEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_DirectiveEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_DirectiveEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<Itest_DirectivesObject>(test_DirectivesEncoder.Factory)
      .AddEncoder<Itest_DirectiveObject>(test_DirectiveEncoder.Factory)
      .AddEncoder<test_Location>(test_LocationEncoder.Factory);
}
