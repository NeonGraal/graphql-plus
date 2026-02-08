//HintName: test_-Global_Intf.gen.cs
// Generated from -Global.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Global;

public interface Itest_AndType
  : Itest_Named
{
  public Itest_Type As_Type { get; set; }
}

public interface Itest_AndTypeObject
  : Itest_NamedObject
{
  public Itest_Type Type { get; set; }
}

public interface Itest_Categories
  : Itest_AndType
{
  public Itest_Category As_Category { get; set; }
}

public interface Itest_CategoriesObject
  : Itest_AndTypeObject
{
  public Itest_Category Category { get; set; }
}

public interface Itest_Category
  : Itest_Aliased
{
}

public interface Itest_CategoryObject
  : Itest_AliasedObject
{
  public Itest_Resolution Resolution { get; set; }
  public Itest_TypeRef<Itest_TypeKind> Output { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
}

public interface Itest_Directives
  : Itest_AndType
{
  public Itest_Directive As_Directive { get; set; }
}

public interface Itest_DirectivesObject
  : Itest_AndTypeObject
{
  public Itest_Directive Directive { get; set; }
}

public interface Itest_Directive
  : Itest_Aliased
{
}

public interface Itest_DirectiveObject
  : Itest_AliasedObject
{
  public ICollection<Itest_InputParam> Parameters { get; set; }
  public ItestBoolean Repeatable { get; set; }
  public IDictionary<test_Location, ItestUnit> Locations { get; set; }
}

public interface Itest_Setting
  : Itest_Named
{
}

public interface Itest_SettingObject
  : Itest_NamedObject
{
  public Itest_Value Value { get; set; }
}
