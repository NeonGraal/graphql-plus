//HintName: test_-Global_Dec.gen.cs
// Generated from {CurrentDirectory}-Global.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Global;

internal class test_AndTypeDecoder
{
  public Itest_Type Type { get; set; }
}

internal class test_CategoriesDecoder
{
  public Itest_Category Category { get; set; }
}

internal class test_CategoryDecoder
{
  public test_Resolution Resolution { get; set; }
  public Itest_TypeRef<Itest_TypeKind> Output { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
}

internal class test_ResolutionDecoder
{
  public string Parallel { get; set; }
  public string Sequential { get; set; }
  public string Single { get; set; }
}

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

internal class test_SettingDecoder
{
  public GqlpValue Value { get; set; }
}

internal static class test__GlobalDecoders
{
  internal static IDecoderRepositoryBuilder Addtest__GlobalDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_AndTypeObject>(r => new test_AndTypeDecoder(r))
      .AddDecoder<Itest_CategoriesObject>(r => new test_CategoriesDecoder(r))
      .AddDecoder<Itest_CategoryObject>(r => new test_CategoryDecoder(r))
      .AddDecoder<test_Resolution>(_ => new test_ResolutionDecoder())
      .AddDecoder<Itest_DirectivesObject>(r => new test_DirectivesDecoder(r))
      .AddDecoder<Itest_DirectiveObject>(r => new test_DirectiveDecoder(r))
      .AddDecoder<test_Location>(_ => new test_LocationDecoder())
      .AddDecoder<Itest_SettingObject>(r => new test_SettingDecoder(r));
}
