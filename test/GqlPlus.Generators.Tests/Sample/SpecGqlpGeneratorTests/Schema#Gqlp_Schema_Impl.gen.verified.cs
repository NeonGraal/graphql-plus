//HintName: Gqlp_Schema_Impl.gen.cs
// Generated from Schema.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Schema;

public class Dual_Opt<TT>
  : I_Opt<TT>
{
  public TT AsT { get; set; }
  public Null AsNull { get; set; }
}

public class Dual_List<TT>
  : I_List<TT>
{
  public TT AsT { get; set; }
}

public class Dual_Dict<TK,TT>
  : I_Dict<TK,TT>
{
  public TT AsT { get; set; }
}

public class Dual_Map<TT>
  : I_Map<TT>
{
  public TT AsT { get; set; }
}

public class Dual_Array<TT>
  : I_Array<TT>
{
  public TT AsT { get; set; }
}

public class Dual_IfElse<TT>
  : I_IfElse<TT>
{
  public TT AsT { get; set; }
}

public class Dual_Set<TK>
  : I_Set<TK>
{
  public Unit AsUnit { get; set; }
}

public class Dual_Mask<TK>
  : I_Mask<TK>
{
  public Boolean As^ { get; set; }
}

public class Union_Key
  : I_Key
{
}

public class Dual_Any
  : I_Any
{
}
