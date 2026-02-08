//HintName: test_object-constraint+Input_Intf.gen.cs
// Generated from object-constraint+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_constraint_Input;

public interface ItestObjCnstInp<Ttype>
{
  public ItestObjCnstInpObject AsObjCnstInp { get; set; }
}

public interface ItestObjCnstInpObject<Ttype>
{
  public Ttype Field { get; set; }
  public Ttype Str { get; set; }
}
