//HintName: test_-Schema_Enc.gen.cs
// Generated from {CurrentDirectory}-Schema.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Schema;

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

internal class test_AliasedEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_AliasedObject>
{
  private readonly IEncoder<Itest_NamedObject> _itest_Named = encoders.EncoderFor<Itest_NamedObject>();
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_AliasedObject input)
    => _itest_Named.Encode(input)
      .AddList("aliases", input.Aliases, _itest_Name);
}

internal class test_NamedEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_NamedObject>
{
  private readonly IEncoder<Itest_DescribedObject> _itest_Described = encoders.EncoderFor<Itest_DescribedObject>();
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_NamedObject input)
    => _itest_Described.Encode(input)
      .AddEncoded("name", input.Name, _itest_Name);
}

internal class test_DescribedEncoder : IEncoder<Itest_DescribedObject>
{
  public Structured Encode(Itest_DescribedObject input)
    => Structured.Empty()
      .Add("description", input.Description.Encode());
}

internal static class test__SchemaEncoders
{
  internal static IEncoderRepositoryBuilder Addtest__SchemaEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<Itest_SchemaObject>(r => new test_SchemaEncoder(r))
      .AddEncoder<Itest_Name>(_ => new test_NameEncoder())
      .AddEncoder<Itest_NameFilter>(_ => new test_NameFilterEncoder())
      .AddEncoder<Itest_AliasedObject>(r => new test_AliasedEncoder(r))
      .AddEncoder<Itest_NamedObject>(r => new test_NamedEncoder(r))
      .AddEncoder<Itest_DescribedObject>(_ => new test_DescribedEncoder());
}
