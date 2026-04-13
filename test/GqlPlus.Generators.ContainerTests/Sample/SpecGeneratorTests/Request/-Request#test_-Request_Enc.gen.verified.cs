//HintName: test_-Request_Enc.gen.cs
// Generated from {CurrentDirectory}-Request.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Request;

internal class test_RequestEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_RequestObject>
{
  private readonly IEncoder<Itest_Identifier> _itest_Identifier = encoders.EncoderFor<Itest_Identifier>();
  private readonly IEncoder<Itest_Operation> _itest_Operation = encoders.EncoderFor<Itest_Operation>();
  private readonly IEncoder<Itest_Any> _itest_Any = encoders.EncoderFor<Itest_Any>();
  public Structured Encode(Itest_RequestObject input)
    => Structured.Empty()
      .AddEncoded("category", input.Category, _itest_Identifier)
      .AddEncoded("operation", input.Operation, _itest_Identifier)
      .AddEncoded("definition", input.Definition, _itest_Operation)
      .AddEncoded("parameters", input.Parameters, _itest_Any);
}

internal class test_IdentifierEncoder : IEncoder<Itest_Identifier>
{
  public Structured Encode(Itest_Identifier input)
    => new(input.Value);
}

internal class test_OperationEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OperationObject>
{
  private readonly IEncoder<Itest_OpVariable> _itest_OpVariable = encoders.EncoderFor<Itest_OpVariable>();
  private readonly IEncoder<Itest_OpDirective> _itest_OpDirective = encoders.EncoderFor<Itest_OpDirective>();
  private readonly IEncoder<Itest_OpFragment> _itest_OpFragment = encoders.EncoderFor<Itest_OpFragment>();
  private readonly IEncoder<Itest_OpResult> _itest_OpResult = encoders.EncoderFor<Itest_OpResult>();
  public Structured Encode(Itest_OperationObject input)
    => Structured.Empty()
      .AddList("variables", input.Variables, _itest_OpVariable)
      .AddList("directives", input.Directives, _itest_OpDirective)
      .AddList("fragments", input.Fragments, _itest_OpFragment)
      .AddEncoded("result", input.Result, _itest_OpResult);
}

internal class test_OpVariableEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpVariableObject>
{
  private readonly IEncoder<Itest_Identifier> _itest_Identifier = encoders.EncoderFor<Itest_Identifier>();
  private readonly IEncoder<Itest_Modifier> _itest_Modifier = encoders.EncoderFor<Itest_Modifier>();
  private readonly IEncoder<GqlpValue> _gqlpValue = encoders.EncoderFor<GqlpValue>();
  private readonly IEncoder<Itest_OpDirective> _itest_OpDirective = encoders.EncoderFor<Itest_OpDirective>();
  public Structured Encode(Itest_OpVariableObject input)
    => Structured.Empty()
      .AddEncoded("name", input.Name, _itest_Identifier)
      .AddEncoded("type", input.Type, _itest_Identifier)
      .AddList("modifiers", input.Modifiers, _itest_Modifier)
      .AddEncoded("default", input.Default, _gqlpValue)
      .AddList("directives", input.Directives, _itest_OpDirective);
}

internal class test_OpDirectiveEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpDirectiveObject>
{
  private readonly IEncoder<Itest_Identifier> _itest_Identifier = encoders.EncoderFor<Itest_Identifier>();
  private readonly IEncoder<Itest_OpArgument> _itest_OpArgument = encoders.EncoderFor<Itest_OpArgument>();
  public Structured Encode(Itest_OpDirectiveObject input)
    => Structured.Empty()
      .AddEncoded("name", input.Name, _itest_Identifier)
      .AddEncoded("argument", input.Argument, _itest_OpArgument);
}

internal class test_OpFragmentEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpFragmentObject>
{
  private readonly IEncoder<Itest_Identifier> _itest_Identifier = encoders.EncoderFor<Itest_Identifier>();
  private readonly IEncoder<Itest_OpDirective> _itest_OpDirective = encoders.EncoderFor<Itest_OpDirective>();
  private readonly IEncoder<Itest_OpObject> _itest_Op = encoders.EncoderFor<Itest_OpObject>();
  public Structured Encode(Itest_OpFragmentObject input)
    => Structured.Empty()
      .AddEncoded("name", input.Name, _itest_Identifier)
      .AddEncoded("type", input.Type, _itest_Identifier)
      .AddList("directives", input.Directives, _itest_OpDirective)
      .AddList("body", input.Body, _itest_Op);
}

internal class test_ModifierKindEncoder : IEncoder<test_ModifierKind>
{
  public Structured Encode(test_ModifierKind input)
    => new(input.ToString(), "_ModifierKind");
}

internal class test_ModifierEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_ModifierObject>
{
  private readonly IEncoder<Itest_Identifier> _itest_Identifier = encoders.EncoderFor<Itest_Identifier>();
  public Structured Encode(Itest_ModifierObject input)
    => Structured.Empty()
      .AddEnum("modifierKind", input.ModifierKind)
      .AddEncoded("by", input.By, _itest_Identifier)
      .Add("optional", input.Optional);
}

internal class test_OpArgumentEncoder : IEncoder<Itest_OpArgumentObject>
{
  public Structured Encode(Itest_OpArgumentObject input)
    => Structured.Empty();
}

internal class test_OpArgValueEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpArgValueObject>
{
  private readonly IEncoder<Itest_Identifier> _itest_Identifier = encoders.EncoderFor<Itest_Identifier>();
  public Structured Encode(Itest_OpArgValueObject input)
    => Structured.Empty()
      .AddEncoded("variable", input.Variable, _itest_Identifier);
}

internal class test_OpArgListEncoder : IEncoder<Itest_OpArgListObject>
{
  public Structured Encode(Itest_OpArgListObject input)
    => Structured.Empty();
}

internal class test_OpArgMapEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpArgMapObject>
{
  private readonly IEncoder<Itest_OpArgValue> _itest_OpArgValue = encoders.EncoderFor<Itest_OpArgValue>();
  private readonly IEncoder<Itest_Identifier> _itest_Identifier = encoders.EncoderFor<Itest_Identifier>();
  public Structured Encode(Itest_OpArgMapObject input)
    => Structured.Empty()
      .AddEncoded("value", input.Value, _itest_OpArgValue)
      .AddEncoded("byVariable", input.ByVariable, _itest_Identifier);
}

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
