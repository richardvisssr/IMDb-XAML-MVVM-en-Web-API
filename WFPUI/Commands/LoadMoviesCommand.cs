

namespace WFPUI.Commands
{
    public class LoadMoviesCommand : CommandBase
    {
        private readonly Action _execute;
        private readonly Func<Task<bool>> _canExecute;
  

        public LoadMoviesCommand(Action execute, Func<Task<bool>> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public override bool CanExecute(object? parameter)
        {
            return base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            _execute();
        }
    }
}
