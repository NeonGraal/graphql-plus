//HintName: test_-Type_Impl.gen.cs
// Generated from -Type.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Type;

public class test_Type
  : Itest_Type
{
}

public class test_BaseType<TKind>
  : test_Aliased
  , Itest_BaseType<TKind>
{
  public TKind TypeKind { get; set; }
}

public class test_ChildType<TKind,TParent>
  : test_BaseType<TKind>
  , Itest_ChildType<TKind,TParent>
{
  public TParent Parent { get; set; }
}

public class test_ParentType<TKind,TItem,TAllItem>
  : test_ChildType<TKind, Itest_Named>
  , Itest_ParentType<TKind,TItem,TAllItem>
{
  public ICollection<TItem> Items { get; set; }
  public ICollection<TAllItem> AllItems { get; set; }
}

public class test_TypeRef<TKind>
  : test_Named
  , Itest_TypeRef<TKind>
{
  public TKind TypeKind { get; set; }
}

public class test_TypeSimple
  : Itest_TypeSimple
{
}

public class test_Collections
  : Itest_Collections
{
}

public class test_ModifierKeyed<TKind>
  : test_Modifier<TKind>
  , Itest_ModifierKeyed<TKind>
{
  public Itest_TypeSimple By { get; set; }
  public bool IsOptional { get; set; }
}

public class test_Modifiers
  : Itest_Modifiers
{
}

public class test_Modifier<TKind>
  : Itest_Modifier<TKind>
{
  public TKind ModifierKind { get; set; }
}
