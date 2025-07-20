//HintName: Model_Intro_+Schema.gen.cs
// Generated from Intro_+Schema.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_Intro__Schema;

public interface I_Schema
  : I_Named
{
  _Categories categories { get; }
  _Directives directives { get; }
  _Type types { get; }
  _Setting settings { get; }
}
public class Output_Schema
  : Output_Named
  , I_Schema
{
  public _Categories categories { get; set; }
  public _Directives directives { get; set; }
  public _Type types { get; set; }
  public _Setting settings { get; set; }
}

public interface I_Identifier
{
}
public class Domain_Identifier
  : I_Identifier
{
}

public interface I_Filter
{
  _NameFilter names { get; }
  Boolean matchAliases { get; }
  _NameFilter aliases { get; }
  Boolean returnByAlias { get; }
  Boolean returnReferencedTypes { get; }
  _NameFilter As_NameFilter { get; }
}
public class Input_Filter
  : I_Filter
{
  public _NameFilter names { get; set; }
  public Boolean matchAliases { get; set; }
  public _NameFilter aliases { get; set; }
  public Boolean returnByAlias { get; set; }
  public Boolean returnReferencedTypes { get; set; }
  public _NameFilter As_NameFilter { get; set; }
}

public interface I_NameFilter
{
}
public class Domain_NameFilter
  : I_NameFilter
{
}

public interface I_CategoryFilter
  : I_Filter
{
  _Resolution resolutions { get; }
}
public class Input_CategoryFilter
  : Input_Filter
  , I_CategoryFilter
{
  public _Resolution resolutions { get; set; }
}

public interface I_TypeFilter
  : I_Filter
{
  _TypeKind kinds { get; }
}
public class Input_TypeFilter
  : Input_Filter
  , I_TypeFilter
{
  public _TypeKind kinds { get; set; }
}

public interface I_Aliased
  : I_Named
{
  _Identifier aliases { get; }
}
public class Dual_Aliased
  : Dual_Named
  , I_Aliased
{
  public _Identifier aliases { get; set; }
}

public interface I_Named
  : I_Described
{
  _Identifier name { get; }
}
public class Dual_Named
  : Dual_Described
  , I_Named
{
  public _Identifier name { get; set; }
}

public interface I_Described
{
  String description { get; }
}
public class Dual_Described
  : I_Described
{
  public String description { get; set; }
}
