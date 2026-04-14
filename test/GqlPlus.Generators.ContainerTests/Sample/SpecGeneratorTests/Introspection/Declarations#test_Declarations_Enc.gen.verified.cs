//HintName: test_Declarations_Enc.gen.cs
// Generated from {CurrentDirectory}Declarations.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
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
}

internal class test_NameEncoder : IEncoder<Itest_Name>
{
  public Structured Encode(Itest_Name input)
    => new(input.Value);
}

internal class test_NameFilterEncoder : IEncoder<Itest_NameFilter>
{
  public Structured Encode(Itest_NameFilter input)
    => new(input.Value);
}

internal static class test_DeclarationsEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_DeclarationsEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<Itest_SchemaObject>(r => new test_SchemaEncoder(r))
      .AddEncoder<Itest_Name>(_ => new test_NameEncoder())
      .AddEncoder<Itest_NameFilter>(_ => new test_NameFilterEncoder());
}
