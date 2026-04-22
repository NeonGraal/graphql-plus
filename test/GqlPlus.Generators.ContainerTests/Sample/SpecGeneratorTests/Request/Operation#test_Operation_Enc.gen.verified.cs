//HintName: test_Operation_Enc.gen.cs
// Generated from {CurrentDirectory}Operation.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Operation;

internal class test_PathEncoder : IEncoder<Itest_Path>
{
  public Structured Encode(Itest_Path input)
    => new(input.Value);

  internal static test_PathEncoder Factory(IEncoderRepository _) => new();
}

internal class test_OpDirectivesEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpDirectivesObject>
{
  private readonly IEncoder<Itest_Identifier> _itest_Identifier = encoders.EncoderFor<Itest_Identifier>();
  private readonly IEncoder<Itest_OpDirective> _itest_OpDirective = encoders.EncoderFor<Itest_OpDirective>();
  public Structured Encode(Itest_OpDirectivesObject input)
    => Structured.Empty()
      .AddEncoded("name", input.Name, _itest_Identifier)
      .Add("description", input.Description.Encode())
      .AddList("directives", input.Directives, _itest_OpDirective);

  internal static test_OpDirectivesEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_OpDirectiveEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_OpArgumentEncoder : IEncoder<Itest_OpArgumentObject>
{
  public Structured Encode(Itest_OpArgumentObject input)
    => Structured.Empty();

  internal static test_OpArgumentEncoder Factory(IEncoderRepository _) => new();
}

internal class test_OpArgValueEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpArgValueObject>
{
  private readonly IEncoder<Itest_Identifier> _itest_Identifier = encoders.EncoderFor<Itest_Identifier>();
  public Structured Encode(Itest_OpArgValueObject input)
    => Structured.Empty()
      .AddEncoded("variable", input.Variable, _itest_Identifier);

  internal static test_OpArgValueEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_OpArgListEncoder : IEncoder<Itest_OpArgListObject>
{
  public Structured Encode(Itest_OpArgListObject input)
    => Structured.Empty();

  internal static test_OpArgListEncoder Factory(IEncoderRepository _) => new();
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

  internal static test_OpArgMapEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_OperationEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_OperationEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<Itest_Path>(test_PathEncoder.Factory)
      .AddEncoder<Itest_OpDirectivesObject>(test_OpDirectivesEncoder.Factory)
      .AddEncoder<Itest_OpDirectiveObject>(test_OpDirectiveEncoder.Factory)
      .AddEncoder<Itest_OpArgumentObject>(test_OpArgumentEncoder.Factory)
      .AddEncoder<Itest_OpArgValueObject>(test_OpArgValueEncoder.Factory)
      .AddEncoder<Itest_OpArgListObject>(test_OpArgListEncoder.Factory)
      .AddEncoder<Itest_OpArgMapObject>(test_OpArgMapEncoder.Factory);
}
