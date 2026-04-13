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

internal class test_FilterEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_FilterObject>
{
  private readonly IEncoder<Itest_NameFilter> _itest_NameFilter = encoders.EncoderFor<Itest_NameFilter>();
  public Structured Encode(Itest_FilterObject input)
    => Structured.Empty()
      .AddList("names", input.Names, _itest_NameFilter)
      .Add("matchAliases", input.MatchAliases)
      .AddList("aliases", input.Aliases, _itest_NameFilter)
      .Add("returnByAlias", input.ReturnByAlias)
      .Add("returnReferencedTypes", input.ReturnReferencedTypes);
}

internal class test_NameFilterEncoder : IEncoder<Itest_NameFilter>
{
  public Structured Encode(Itest_NameFilter input)
    => new(input.Value);
}

internal class test_CategoryFilterEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_CategoryFilterObject>
{
  private readonly IEncoder<Itest_FilterObject> _itest_Filter = encoders.EncoderFor<Itest_FilterObject>();
  private readonly IEncoder<Itest_Resolution> _itest_Resolution = encoders.EncoderFor<Itest_Resolution>();
  public Structured Encode(Itest_CategoryFilterObject input)
    => _itest_Filter.Encode(input)
      .AddList("resolutions", input.Resolutions, _itest_Resolution);
}

internal class test_TypeFilterEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_TypeFilterObject>
{
  private readonly IEncoder<Itest_FilterObject> _itest_Filter = encoders.EncoderFor<Itest_FilterObject>();
  private readonly IEncoder<Itest_TypeKind> _itest_TypeKind = encoders.EncoderFor<Itest_TypeKind>();
  public Structured Encode(Itest_TypeFilterObject input)
    => _itest_Filter.Encode(input)
      .AddList("kinds", input.Kinds, _itest_TypeKind);
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
