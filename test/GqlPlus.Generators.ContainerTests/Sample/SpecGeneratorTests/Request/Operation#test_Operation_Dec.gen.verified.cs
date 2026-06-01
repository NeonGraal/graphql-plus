//HintName: test_Operation_Dec.gen.cs
// Generated from {CurrentDirectory}Operation.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Operation;

internal class test_OperationDecoder : NullDecoder<Itest_OperationObject>
{
  public ICollection<Itest_OpVariable> Variables { get; set; } = default!;
  public ICollection<Itest_OpDirective> Directives { get; set; } = default!;
  public ICollection<Itest_OpFragment> Fragments { get; set; } = default!;
  public Itest_OpResult Result { get; set; } = default!;
  public IDictionary<Itest_Path, ICollection<Itest_OpSelection>> Selections { get; set; } = default!;

  internal static test_OperationDecoder Factory(IDecoderRepository _) => new();
}

internal class test_PathDecoder : NullDecoder<Itest_Path>
{

  internal static test_PathDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpDirectivesDecoder : NullDecoder<Itest_OpDirectivesObject>
{
  public Itest_Identifier Name { get; set; } = default!;
  public ICollection<string> Description { get; set; } = default!;
  public ICollection<Itest_OpDirective> Directives { get; set; } = default!;

  internal static test_OpDirectivesDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpVariableDecoder : NullDecoder<Itest_OpVariableObject>
{
  public Itest_Identifier? Type { get; set; } = default!;
  public ICollection<Itest_Modifiers> Modifiers { get; set; } = default!;
  public GqlpValue? DefaultValue { get; set; } = default!;

  internal static test_OpVariableDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpDirectiveDecoder : NullDecoder<Itest_OpDirectiveObject>
{
  public Itest_Identifier Name { get; set; } = default!;
  public Itest_OpArgument? Argument { get; set; } = default!;

  internal static test_OpDirectiveDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpFragmentDecoder : NullDecoder<Itest_OpFragmentObject>
{
  public Itest_Identifier? Type { get; set; } = default!;

  internal static test_OpFragmentDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpResultDecoder : NullDecoder<Itest_OpResultObject>
{
  public Itest_Identifier? Domain { get; set; } = default!;
  public Itest_OpArgument? Argument { get; set; } = default!;

  internal static test_OpResultDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgumentDecoder : NullDecoder<Itest_OpArgumentObject>
{

  internal static test_OpArgumentDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgValueDecoder : NullDecoder<Itest_OpArgValueObject>
{
  public Itest_Identifier Variable { get; set; } = default!;

  internal static test_OpArgValueDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgListDecoder : NullDecoder<Itest_OpArgListObject>
{

  internal static test_OpArgListDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgMapDecoder : NullDecoder<Itest_OpArgMapObject>
{
  public Itest_OpArgValue Value { get; set; } = default!;
  public Itest_Identifier ByVariable { get; set; } = default!;

  internal static test_OpArgMapDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_OperationDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_OperationDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_OperationObject>(test_OperationDecoder.Factory)
      .AddDecoder<Itest_Path>(test_PathDecoder.Factory)
      .AddDecoder<Itest_OpDirectivesObject>(test_OpDirectivesDecoder.Factory)
      .AddDecoder<Itest_OpVariableObject>(test_OpVariableDecoder.Factory)
      .AddDecoder<Itest_OpDirectiveObject>(test_OpDirectiveDecoder.Factory)
      .AddDecoder<Itest_OpFragmentObject>(test_OpFragmentDecoder.Factory)
      .AddDecoder<Itest_OpResultObject>(test_OpResultDecoder.Factory)
      .AddDecoder<Itest_OpArgumentObject>(test_OpArgumentDecoder.Factory)
      .AddDecoder<Itest_OpArgValueObject>(test_OpArgValueDecoder.Factory)
      .AddDecoder<Itest_OpArgListObject>(test_OpArgListDecoder.Factory)
      .AddDecoder<Itest_OpArgMapObject>(test_OpArgMapDecoder.Factory);
}
