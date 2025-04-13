//HintName: Model_generic-alt-arg-descr+input.gen.cs
// Generated from generic-alt-arg-descr+input.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_arg_descr_input;

public interface IInpGnrcAltArgDescr
{
  RefInpGnrcAltArgDescr < 'Test Descr' I@074/0001 $type > AsRefInpGnrcAltArgDescr { get; }
}
public class InputInpGnrcAltArgDescr
{
  public RefInpGnrcAltArgDescr < 'Test Descr' I@074/0001 $type > AsRefInpGnrcAltArgDescr { get; set; }
}

public interface IRefInpGnrcAltArgDescr
{
  $ref Asref { get; }
}
public class InputRefInpGnrcAltArgDescr
{
  public $ref Asref { get; set; }
}
