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
    => input.Value!.Encode();

  internal static test_NameEncoder Factory(IEncoderRepository _) => new();
}

internal class test_FilterEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_FilterObject>
{
  private readonly IEncoder<Itest_NameFilter> _itest_NameFilter = encoders.EncoderFor<Itest_NameFilter>();
  public Structured Encode(Itest_FilterObject input)
    => Structured.Empty()
      .AddList("names", input.Names, _itest_NameFilter)
      .AddIf(input.MatchAliases is not null, onTrue: t => t.Add("matchAliases", input.MatchAliases!.Encode()))
      .AddList("aliases", input.Aliases, _itest_NameFilter)
      .AddIf(input.ReturnByAlias is not null, onTrue: t => t.Add("returnByAlias", input.ReturnByAlias!.Encode()))
      .AddIf(input.ReturnReferencedTypes is not null, onTrue: t => t.Add("returnReferencedTypes", input.ReturnReferencedTypes!.Encode()));

  internal static test_FilterEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_NameFilterEncoder : IEncoder<Itest_NameFilter>
{
  public Structured Encode(Itest_NameFilter input)
    => input.Value!.Encode();

  internal static test_NameFilterEncoder Factory(IEncoderRepository _) => new();
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

  internal static test_CategoryFilterEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_TypeFilterEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_DeclarationsEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_DeclarationsEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<Itest_SchemaObject>(test_SchemaEncoder.Factory)
      .AddEncoder<Itest_Name>(test_NameEncoder.Factory)
      .AddEncoder<Itest_FilterObject>(test_FilterEncoder.Factory)
      .AddEncoder<Itest_NameFilter>(test_NameFilterEncoder.Factory)
      .AddEncoder<Itest_CategoryFilterObject>(test_CategoryFilterEncoder.Factory)
      .AddEncoder<Itest_TypeFilterObject>(test_TypeFilterEncoder.Factory);
}
