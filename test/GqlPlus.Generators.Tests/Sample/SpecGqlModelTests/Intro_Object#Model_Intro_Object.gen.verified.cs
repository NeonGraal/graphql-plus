//HintName: Model_Intro_Object.gen.cs
// Generated from Intro_Object.graphql+

/*
*/

namespace GqlTest.Model_Intro_Object;

public interface I_TypeObject
{
  _ObjTypeParam typeParams { get; }
  $field fields { get; }
  $alternate alternates { get; }
  _ObjectFor < I@032/0006 $field > allFields { get; }
  _ObjectFor < I@036/0007 $alternate > allAlternates { get; }
}
public class Output_TypeObject
{
  public _ObjTypeParam typeParams { get; set; }
  public $field fields { get; set; }
  public $alternate alternates { get; set; }
  public _ObjectFor < I@032/0006 $field > allFields { get; set; }
  public _ObjectFor < I@036/0007 $alternate > allAlternates { get; set; }
}

public interface I_ObjConstraint
{
  _TypeSimple As_TypeSimple { get; }
  $base Asbase { get; }
}
public class Output_ObjConstraint
{
  public _TypeSimple As_TypeSimple { get; set; }
  public $base Asbase { get; set; }
}

public interface I_ObjType
{
  _BaseType < I@017/0015 _TypeKind.Internal > As_BaseType { get; }
  _ObjConstraint < I@023/0016 $base > As_ObjConstraint { get; }
}
public class Output_ObjType
{
  public _BaseType < I@017/0015 _TypeKind.Internal > As_BaseType { get; set; }
  public _ObjConstraint < I@023/0016 $base > As_ObjConstraint { get; set; }
}

public interface I_ObjBase
{
  $arg typeArgs { get; }
  _ObjTypeParam As_ObjTypeParam { get; }
}
public class Output_ObjBase
{
  public $arg typeArgs { get; set; }
  public _ObjTypeParam As_ObjTypeParam { get; set; }
}

public interface I_ObjTypeArg
{
  _ObjTypeParam As_ObjTypeParam { get; }
}
public class Output_ObjTypeArg
{
  public _ObjTypeParam As_ObjTypeParam { get; set; }
}

public interface I_TypeParam
  : I_TypeParam
{
}
public class Domain_TypeParam
  : Domain_Identifier
  , I_TypeParam
{
}

public interface I_ObjTypeParam
{
  _TypeParam typeParam { get; }
}
public class Output_ObjTypeParam
{
  public _TypeParam typeParam { get; set; }
}

public interface I_Alternate
{
  _Collections collections { get; }
}
public class Output_Alternate
{
  public _Collections collections { get; set; }
}

public interface I_ObjectFor
{
  _Identifier object { get; }
}
public class Output_ObjectFor
{
  public _Identifier object { get; set; }
}

public interface I_Field
{
  $base type { get; }
  _Modifiers modifiers { get; }
}
public class Output_Field
{
  public $base type { get; set; }
  public _Modifiers modifiers { get; set; }
}
