//HintName: test_Directive_Dec.gen.cs
// Generated from {CurrentDirectory}Directive.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Directive;

internal class test_DirectivesDecoder
{
  public Itest_Directive Directive { get; set; }
}

internal class test_DirectiveDecoder
{
  public Itest_InputFieldType? Parameter { get; set; }
  public bool Repeatable { get; set; }
  public IDictionary<test_Location, GqlpUnit> Locations { get; set; }
}

internal class test_LocationDecoder
{
  public string Operation { get; set; }
  public string Variable { get; set; }
  public string Field { get; set; }
  public string Inline { get; set; }
  public string Spread { get; set; }
  public string Fragment { get; set; }
}
