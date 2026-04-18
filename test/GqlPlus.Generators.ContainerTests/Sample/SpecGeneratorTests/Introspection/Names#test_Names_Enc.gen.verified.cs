//HintName: test_Names_Enc.gen.cs
// Generated from {CurrentDirectory}Names.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Names;

internal class test_AliasedEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_AliasedObject>
{
  private readonly IEncoder<Itest_NamedObject> _itest_Named = encoders.EncoderFor<Itest_NamedObject>();
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_AliasedObject input)
    => _itest_Named.Encode(input)
      .AddList("aliases", input.Aliases, _itest_Name);

  internal static test_AliasedEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_NamedEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_DescribedEncoder : IEncoder<Itest_DescribedObject>
{
  public Structured Encode(Itest_DescribedObject input)
    => Structured.Empty()
      .Add("description", input.Description.Encode());

  internal static test_DescribedEncoder Factory(IEncoderRepository _) => new();
}

internal class test_AndTypeEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_AndTypeObject>
{
  private readonly IEncoder<Itest_NamedObject> _itest_Named = encoders.EncoderFor<Itest_NamedObject>();
  private readonly IEncoder<Itest_Type> _itest_Type = encoders.EncoderFor<Itest_Type>();
  public Structured Encode(Itest_AndTypeObject input)
    => _itest_Named.Encode(input)
      .AddEncoded("type", input.Type, _itest_Type);

  internal static test_AndTypeEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_NamesEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_NamesEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<Itest_AliasedObject>(test_AliasedEncoder.Factory)
      .AddEncoder<Itest_NamedObject>(test_NamedEncoder.Factory)
      .AddEncoder<Itest_DescribedObject>(test_DescribedEncoder.Factory)
      .AddEncoder<Itest_AndTypeObject>(test_AndTypeEncoder.Factory);
}
