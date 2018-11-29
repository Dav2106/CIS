using BE.CiS;
using DAC.CiS;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.CiS
{
    public class UsuarioBL
    {
        UsuarioDAC usuarioDAC = new UsuarioDAC();
        
        public bool InsertarUsuario(Usuario usuario)
        {
            return usuarioDAC.InsertarUsuario(usuario);
        }

        public bool ActualizarUsuario(Usuario usuario)
        {
            return usuarioDAC.ActualizarUsuario(usuario);
        }

        public Usuario GetUsuario(int id)
        {
            return usuarioDAC.GetUsuario(id);
        }

        public List<Usuario> GetUsuarios()
        {
            return usuarioDAC.GetUsuarios();
        }
    }
}
