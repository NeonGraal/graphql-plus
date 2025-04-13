//HintName: Model_Intro_Declarations.gen.cs
// Generated from Intro_Declarations.graphql+

/*
*/

namespace GqlTest.Model_Intro_Declarations;

public interface I_Schema
{
  _Categories categories { get; }
  _Directives directives { get; }
  _Type types { get; }
  _Setting settings { get; }
}
public class Output_Schema
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
{
  _Resolution resolutions { get; }
}
public class Input_CategoryFilter
{
  public _Resolution resolutions { get; set; }
}

public interface I_TypeFilter
{
  _TypeKind kinds { get; }
}
public class Input_TypeFilter
{
  public _TypeKind kinds { get; set; }
}
