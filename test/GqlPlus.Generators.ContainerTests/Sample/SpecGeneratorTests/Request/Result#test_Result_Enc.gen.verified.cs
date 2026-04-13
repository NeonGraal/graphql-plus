//HintName: test_Result_Enc.gen.cs
// Generated from {CurrentDirectory}Result.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Result;

internal class test_OpResultEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpResultObject>
{
  private readonly IEncoder<Itest_Identifier> _itest_Identifier = encoders.EncoderFor<Itest_Identifier>();
  private readonly IEncoder<Itest_OpArgument> _itest_OpArgument = encoders.EncoderFor<Itest_OpArgument>();
  private readonly IEncoder<Itest_OpObject> _itest_Op = encoders.EncoderFor<Itest_OpObject>();
  public Structured Encode(Itest_OpResultObject input)
    => Structured.Empty()
      .AddEncoded("domain", input.Domain, _itest_Identifier)
      .AddEncoded("argument", input.Argument, _itest_OpArgument)
      .AddList("body", input.Body, _itest_Op);
}

internal class test_OpObjectEncoder : IEncoder<Itest_OpObjectObject>
{
  public Structured Encode(Itest_OpObjectObject input)
    => Structured.Empty();
}

internal class test_OpFieldEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpFieldObject>
{
  private readonly IEncoder<Itest_Identifier> _itest_Identifier = encoders.EncoderFor<Itest_Identifier>();
  private readonly IEncoder<Itest_OpArgument> _itest_OpArgument = encoders.EncoderFor<Itest_OpArgument>();
  private readonly IEncoder<Itest_Modifier> _itest_Modifier = encoders.EncoderFor<Itest_Modifier>();
  private readonly IEncoder<Itest_OpDirective> _itest_OpDirective = encoders.EncoderFor<Itest_OpDirective>();
  public Structured Encode(Itest_OpFieldObject input)
    => Structured.Empty()
      .AddEncoded("alias", input.Alias, _itest_Identifier)
      .AddEncoded("field", input.Field, _itest_Identifier)
      .AddEncoded("argument", input.Argument, _itest_OpArgument)
      .AddList("modifiers", input.Modifiers, _itest_Modifier)
      .AddList("directives", input.Directives, _itest_OpDirective)
      .Add("body", input.Body);
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
      .AddList("directives", input.Directives, _itest_OpDirective)
      .Add("body", input.Body);
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
}
