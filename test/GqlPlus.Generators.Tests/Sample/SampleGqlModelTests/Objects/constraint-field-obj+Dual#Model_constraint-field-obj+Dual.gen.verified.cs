//HintName: Model_constraint-field-obj+Dual.gen.cs
// Generated from constraint-field-obj+Dual.graphql+

/*
*/

namespace GqlTest.Model_constraint_field_obj_Dual;

public interface ICnstFieldObjDual
  : IRefCnstFieldObjDual
{
}
public class DualCnstFieldObjDual
  : DualRefCnstFieldObjDual
  , ICnstFieldObjDual
{
}

public interface IRefCnstFieldObjDual<Tref>
{
  Tref field { get; }
}
public class DualRefCnstFieldObjDual<Tref>
  : IRefCnstFieldObjDual<Tref>
{
  public Tref field { get; set; }
}

public interface IPrntCnstFieldObjDual
{
  String AsString { get; }
}
public class DualPrntCnstFieldObjDual
  : IPrntCnstFieldObjDual
{
  public String AsString { get; set; }
}

public interface IAltCnstFieldObjDual
  : IPrntCnstFieldObjDual
{
  Number alt { get; }
}
public class DualAltCnstFieldObjDual
  : DualPrntCnstFieldObjDual
  , IAltCnstFieldObjDual
{
  public Number alt { get; set; }
}
