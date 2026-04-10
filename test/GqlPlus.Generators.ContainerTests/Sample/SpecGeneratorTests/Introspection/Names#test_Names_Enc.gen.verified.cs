//HintName: test_Names_Enc.gen.cs
// Generated from {CurrentDirectory}Names.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Names;

internal class test_AliasedEncoder
{
  public ICollection<Itest_Name> Aliases { get; set; }
}

internal class test_NamedEncoder
{
  public Itest_Name Name { get; set; }
}

internal class test_DescribedEncoder
{
  public ICollection<string> Description { get; set; }
}

internal class test_AndTypeEncoder
{
  public Itest_Type Type { get; set; }
}
