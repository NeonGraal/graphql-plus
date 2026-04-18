//HintName: test_constraint-enum+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Output;

internal class testEnumCnstEnumOutpDecoder
{
  public string cnstEnumOutp { get; set; }

  internal static testEnumCnstEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_enum_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_enum_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumCnstEnumOutp>(testEnumCnstEnumOutpDecoder.Factory);
}
