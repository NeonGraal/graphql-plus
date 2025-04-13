//HintName: Model_Intro_Dual.gen.cs
// Generated from Intro_Dual.graphql+

/*
*/

namespace GqlTest.Model_Intro_Dual;

public interface I_TypeDual
  : I_TypeObject
{
}
public class Output_TypeDual
  : Output_TypeObject
  , I_TypeDual
{
}

public interface I_DualBase
  : I_ObjBase
{
  _Identifier dual { get; }
}
public class Output_DualBase
  : Output_ObjBase
  , I_DualBase
{
  public _Identifier dual { get; set; }
}

public interface I_DualField
  : I_Field
{
}
public class Output_DualField
  : Output_Field
  , I_DualField
{
}

public interface I_DualAlternate
  : I_Alternate
{
  _Identifier dual { get; }
}
public class Output_DualAlternate
  : Output_Alternate
  , I_DualAlternate
{
  public _Identifier dual { get; set; }
}

public interface I_DualTypeArg
  : I_ObjTypeArg
{
  _Identifier dual { get; }
}
public class Output_DualTypeArg
  : Output_ObjTypeArg
  , I_DualTypeArg
{
  public _Identifier dual { get; set; }
}
