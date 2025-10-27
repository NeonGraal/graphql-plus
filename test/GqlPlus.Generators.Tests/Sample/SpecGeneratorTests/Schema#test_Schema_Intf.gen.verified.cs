//HintName: test_Schema_Intf.gen.cs
// Generated from Schema.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Schema;

public interface Itest_Opt<TT>
{
  TT AsT { get; }
  Null AsNull { get; }
}

public interface Itest_List<TT>
{
  TT AsT { get; }
}

public interface Itest_Dict<TK,TT>
{
  TT AsT { get; }
}

public interface Itest_Map<TT>
{
  TT AsT { get; }
}

public interface Itest_Array<TT>
{
  TT AsT { get; }
}

public interface Itest_IfElse<TT>
{
  TT AsT { get; }
}

public interface Itest_Set<TK>
{
  Unit AsUnit { get; }
}

public interface Itest_Mask<TK>
{
  Boolean As^ { get; }
}

public interface Itest_Key
{
}

public interface Itest_Any
{
}
