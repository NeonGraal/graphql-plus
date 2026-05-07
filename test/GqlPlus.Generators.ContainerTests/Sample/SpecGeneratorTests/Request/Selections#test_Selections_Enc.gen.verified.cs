//HintName: test_Selections_Enc.gen.cs
// Generated from {CurrentDirectory}Selections.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Selections;

internal class test_OpSelectionEncoder : IEncoder<Itest_OpSelectionObject>
{
  public Structured Encode(Itest_OpSelectionObject input)
    => Structured.Empty();

  internal static test_OpSelectionEncoder Factory(IEncoderRepository _) => new();
}

internal class test_OpFieldEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpFieldObject>
{
  private readonly IEncoder<Itest_OpDirectivesObject> _itest_OpDirectives = encoders.EncoderFor<Itest_OpDirectivesObject>();
  private readonly IEncoder<Itest_Identifier> _itest_Identifier = encoders.EncoderFor<Itest_Identifier>();
  private readonly IEncoder<Itest_OpArgument> _itest_OpArgument = encoders.EncoderFor<Itest_OpArgument>();
  private readonly IEncoder<Itest_Modifiers> _itest_Modifiers = encoders.EncoderFor<Itest_Modifiers>();
  public Structured Encode(Itest_OpFieldObject input)
    => _itest_OpDirectives.Encode(input)
      .AddEncoded("fieldAlias", input.FieldAlias, _itest_Identifier)
      .AddEncoded("argument", input.Argument, _itest_OpArgument)
      .AddList("modifiers", input.Modifiers, _itest_Modifiers);

  internal static test_OpFieldEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_OpInlineEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpInlineObject>
{
  private readonly IEncoder<Itest_Identifier> _itest_Identifier = encoders.EncoderFor<Itest_Identifier>();
  private readonly IEncoder<Itest_OpDirective> _itest_OpDirective = encoders.EncoderFor<Itest_OpDirective>();
  public Structured Encode(Itest_OpInlineObject input)
    => Structured.Empty()
      .AddEncoded("type", input.Type, _itest_Identifier)
      .AddList("directives", input.Directives, _itest_OpDirective);

  internal static test_OpInlineEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_OpSpreadEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpSpreadObject>
{
  private readonly IEncoder<Itest_Identifier> _itest_Identifier = encoders.EncoderFor<Itest_Identifier>();
  private readonly IEncoder<Itest_OpDirective> _itest_OpDirective = encoders.EncoderFor<Itest_OpDirective>();
  public Structured Encode(Itest_OpSpreadObject input)
    => Structured.Empty()
      .AddEncoded("fragment", input.Fragment, _itest_Identifier)
      .AddList("directives", input.Directives, _itest_OpDirective);

  internal static test_OpSpreadEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_SelectionsEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_SelectionsEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<Itest_OpSelectionObject>(test_OpSelectionEncoder.Factory)
      .AddEncoder<Itest_OpFieldObject>(test_OpFieldEncoder.Factory)
      .AddEncoder<Itest_OpInlineObject>(test_OpInlineEncoder.Factory)
      .AddEncoder<Itest_OpSpreadObject>(test_OpSpreadEncoder.Factory);
}
