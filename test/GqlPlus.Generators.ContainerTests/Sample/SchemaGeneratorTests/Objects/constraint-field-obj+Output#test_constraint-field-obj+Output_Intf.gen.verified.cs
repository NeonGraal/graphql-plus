//HintName: test_constraint-field-obj+Output_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-field-obj+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Output;

public interface ItestCnstFieldObjOutp
  : ItestRefCnstFieldObjOutp<ItestAltCnstFieldObjOutp>
{
  ItestCnstFieldObjOutpObject? As_CnstFieldObjOutp { get; }
}

public interface ItestCnstFieldObjOutpObject
  : ItestRefCnstFieldObjOutpObject<ItestAltCnstFieldObjOutp>
{
}

public interface ItestRefCnstFieldObjOutp<TRef>
  : IGqlpModelImplementationBase
{
  ItestRefCnstFieldObjOutpObject<TRef>? As_RefCnstFieldObjOutp { get; }
}

public interface ItestRefCnstFieldObjOutpObject<TRef>
  : IGqlpModelImplementationBase
{
  TRef Field { get; }
}

public interface ItestPrntCnstFieldObjOutp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestPrntCnstFieldObjOutpObject? As_PrntCnstFieldObjOutp { get; }
}

public interface ItestPrntCnstFieldObjOutpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestAltCnstFieldObjOutp
  : ItestPrntCnstFieldObjOutp
{
  ItestAltCnstFieldObjOutpObject? As_AltCnstFieldObjOutp { get; }
}

public interface ItestAltCnstFieldObjOutpObject
  : ItestPrntCnstFieldObjOutpObject
{
  decimal Alt { get; }
}
