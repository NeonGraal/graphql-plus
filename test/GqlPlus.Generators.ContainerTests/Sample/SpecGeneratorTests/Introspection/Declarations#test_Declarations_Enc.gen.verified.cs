//HintName: test_Declarations_Enc.gen.cs
// Generated from {CurrentDirectory}Declarations.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Declarations;

internal class test_SchemaEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_SchemaObject>
{
  private readonly IEncoder<Itest_NamedObject> _itest_Named = encoders.EncoderFor<Itest_NamedObject>();
  public Structured Encode(Itest_SchemaObject input)
    => _itest_Named.Encode(input);

  internal static test_SchemaEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_NameEncoder : IEncoder<Itest_Name>
{
  public Structured Encode(Itest_Name input)
    => new(input.Value);

  internal static test_NameEncoder Factory(IEncoderRepository _) => new();
}

internal class test_NameFilterEncoder : IEncoder<Itest_NameFilter>
{
  public Structured Encode(Itest_NameFilter input)
    => new(input.Value);

  internal static test_NameFilterEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_DeclarationsEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_DeclarationsEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<Itest_SchemaObject>(test_SchemaEncoder.Factory)
      .AddEncoder<Itest_Name>(test_NameEncoder.Factory)
      .AddEncoder<Itest_NameFilter>(test_NameFilterEncoder.Factory);
}
