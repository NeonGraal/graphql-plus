﻿//HintName: Model_Intro_Common.gen.cs
// Generated from Intro_Common.graphql+

/*
*/

namespace GqlTest.Model_Intro_Common;

public interface I_Type
{
  _BaseType < I@017/0002 _TypeKind.Basic > As_BaseType { get; }
  _BaseType < I@017/0003 _TypeKind.Internal > As_BaseType { get; }
  _TypeDual As_TypeDual { get; }
  _TypeEnum As_TypeEnum { get; }
  _TypeInput As_TypeInput { get; }
  _TypeOutput As_TypeOutput { get; }
  _TypeDomain As_TypeDomain { get; }
  _TypeUnion As_TypeUnion { get; }
}
public class Output_Type
{
  public _BaseType < I@017/0002 _TypeKind.Basic > As_BaseType { get; set; }
  public _BaseType < I@017/0003 _TypeKind.Internal > As_BaseType { get; set; }
  public _TypeDual As_TypeDual { get; set; }
  public _TypeEnum As_TypeEnum { get; set; }
  public _TypeInput As_TypeInput { get; set; }
  public _TypeOutput As_TypeOutput { get; set; }
  public _TypeDomain As_TypeDomain { get; set; }
  public _TypeUnion As_TypeUnion { get; set; }
}

public interface I_BaseType
{
  $kind typeKind { get; }
}
public class Output_BaseType
{
  public $kind typeKind { get; set; }
}

public interface I_ChildType
{
  $parent parent { get; }
}
public class Output_ChildType
{
  public $parent parent { get; set; }
}

public interface I_ParentType
{
  $item items { get; }
  $allItem allItems { get; }
}
public class Output_ParentType
{
  public $item items { get; set; }
  public $allItem allItems { get; set; }
}

public enum _SimpleKind
{
  Basic,
  Enum,
  Internal,
  Domain,
  Union,
}

public enum _TypeKind
{
  Basic = _SimpleKind.Basic,,
  Enum = _SimpleKind.Enum,,
  Internal = _SimpleKind.Internal,,
  Domain = _SimpleKind.Domain,,
  Union = _SimpleKind.Union,,
  Dual,
  Input,
  Output,
}

public interface I_TypeRef
{
  $kind typeKind { get; }
  _Identifier name { get; }
}
public class Output_TypeRef
{
  public $kind typeKind { get; set; }
  public _Identifier name { get; set; }
}

public interface I_TypeSimple
{
  _TypeRef < I@016/0039 _TypeKind.Basic > As_TypeRef { get; }
  _TypeRef < I@016/0040 _TypeKind.Enum > As_TypeRef { get; }
  _TypeRef < I@016/0041 _TypeKind.Domain > As_TypeRef { get; }
  _TypeRef < I@016/0042 _TypeKind.Union > As_TypeRef { get; }
}
public class Output_TypeSimple
{
  public _TypeRef < I@016/0039 _TypeKind.Basic > As_TypeRef { get; set; }
  public _TypeRef < I@016/0040 _TypeKind.Enum > As_TypeRef { get; set; }
  public _TypeRef < I@016/0041 _TypeKind.Domain > As_TypeRef { get; set; }
  public _TypeRef < I@016/0042 _TypeKind.Union > As_TypeRef { get; set; }
}
