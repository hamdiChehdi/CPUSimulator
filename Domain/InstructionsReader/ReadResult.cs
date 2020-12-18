namespace Domain
{
    using Domain.Instructions;

    public record ReadResult(ICPUInstruction[] Instructions, bool isFailed, int lineError);
}
