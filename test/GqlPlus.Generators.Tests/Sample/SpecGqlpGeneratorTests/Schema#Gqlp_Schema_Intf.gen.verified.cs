//HintName: Gqlp_Schema_Intf.gen.cs
// Generated from Schema.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Schema;

public interface I_Opt<TT>
{
  TT AsT { get; }
  Null AsNull { get; }
}

public interface I_List<TT>
{
  TT AsT { get; }
}

public interface I_Dict<TK,TT>
{
  TT AsT { get; }
}

public interface I_Map<TT>
{
  TT AsT { get; }
}

public interface I_Array<TT>
{
  TT AsT { get; }
}

public interface I_IfElse<TT>
{
  TT AsT { get; }
}

public interface I_Set<TK>
{
  Unit AsUnit { get; }
}

public interface I_Mask<TK>
{
  Boolean As^ { get; }
}

public interface I_Key
{
}

public interface I_Any
{
}
