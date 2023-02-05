using System;

namespace SunSharp.Unity
{
    public class LibraryProxy : ISunVoxLib
    {
        private ISunVoxLib _instance;
        private object _lock;
        private bool _destroyed;

        public LibraryProxy(ISunVoxLib instance)
        {
            _lock = new object();
            _instance = instance;
        }

        public void Destroy()
        {
            lock (_lock)
            {
                _destroyed = true;
            }
        }

        private void ThrowIfDestroyed()
        {
            if (_destroyed)
                throw new InvalidOperationException("Proxy object was destroyed");
        }

        #region ISunVoxLib

        public int sv_audio_callback(IntPtr buf, int frames, int latency, uint out_time)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_audio_callback(buf, frames, latency, out_time);
            }
        }

        public int sv_audio_callback2(IntPtr buf, int frames, int latency, uint out_time, int in_type, int in_channels, IntPtr in_buf)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_audio_callback2(buf, frames, latency, out_time, in_type, in_channels, in_buf);
            }
        }

        public int sv_close_slot(int slot)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_close_slot(slot);
            }
        }

        public int sv_connect_module(int slot, int source, int destination)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_connect_module(slot, source, destination);
            }
        }

        public int sv_deinit()
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_deinit();
            }
        }

        public int sv_disconnect_module(int slot, int source, int destination)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_disconnect_module(slot, source, destination);
            }
        }

        public int sv_end_of_song(int slot)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_end_of_song(slot);
            }
        }

        public int sv_find_module(int slot, IntPtr name)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_find_module(slot, name);
            }
        }

        public int sv_find_pattern(int slot, IntPtr name)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_find_pattern(slot, name);
            }
        }

        public int sv_get_autostop(int slot)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_autostop(slot);
            }
        }

        public int sv_get_current_line(int slot)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_current_line(slot);
            }
        }

        public int sv_get_current_line2(int slot)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_current_line2(slot);
            }
        }

        public int sv_get_current_signal_level(int slot, int channel)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_current_signal_level(slot, channel);
            }
        }

        public IntPtr sv_get_log(int size)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_log(size);
            }
        }

        public int sv_get_module_color(int slot, int mod_num)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_module_color(slot, mod_num);
            }
        }

        public int sv_get_module_ctl_group(int slot, int mod_num, int ctl_num)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_module_ctl_group(slot, mod_num, ctl_num);
            }
        }

        public int sv_get_module_ctl_max(int slot, int mod_num, int ctl_num, int scaled)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_module_ctl_max(slot, mod_num, ctl_num, scaled);
            }
        }

        public int sv_get_module_ctl_min(int slot, int mod_num, int ctl_num, int scaled)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_module_ctl_min(slot, mod_num, ctl_num, scaled);
            }
        }

        public IntPtr sv_get_module_ctl_name(int slot, int mod_num, int ctl_num)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_module_ctl_name(slot, mod_num, ctl_num);
            }
        }

        public int sv_get_module_ctl_offset(int slot, int mod_num, int ctl_num)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_module_ctl_offset(slot, mod_num, ctl_num);
            }
        }

        public int sv_get_module_ctl_type(int slot, int mod_num, int ctl_num)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_module_ctl_type(slot, mod_num, ctl_num);
            }
        }

        public int sv_get_module_ctl_value(int slot, int mod_num, int ctl_num, int scaled)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_module_ctl_value(slot, mod_num, ctl_num, scaled);
            }
        }

        public uint sv_get_module_finetune(int slot, int mod_num)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_module_finetune(slot, mod_num);
            }
        }

        public uint sv_get_module_flags(int slot, int mod_num)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_module_flags(slot, mod_num);
            }
        }

        public IntPtr sv_get_module_inputs(int slot, int mod_num)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_module_inputs(slot, mod_num);
            }
        }

        public IntPtr sv_get_module_name(int slot, int mod_num)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_module_name(slot, mod_num);
            }
        }

        public IntPtr sv_get_module_outputs(int slot, int mod_num)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_module_outputs(slot, mod_num);
            }
        }

        public uint sv_get_module_scope2(int slot, int mod_num, int channel, IntPtr dest_buf, uint samples_to_read)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_module_scope2(slot, mod_num, channel, dest_buf, samples_to_read);
            }
        }

        public IntPtr sv_get_module_type(int slot, int mod_num)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_module_type(slot, mod_num);
            }
        }

        public uint sv_get_module_xy(int slot, int mod_num)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_module_xy(slot, mod_num);
            }
        }

        public int sv_get_number_of_modules(int slot)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_number_of_modules(slot);
            }
        }

        public int sv_get_number_of_module_ctls(int slot, int mod_num)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_number_of_module_ctls(slot, mod_num);
            }
        }

        public int sv_get_number_of_patterns(int slot)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_number_of_patterns(slot);
            }
        }

        public IntPtr sv_get_pattern_data(int slot, int pat_num)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_pattern_data(slot, pat_num);
            }
        }

        public int sv_get_pattern_event(int slot, int pat_num, int track, int line, int column)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_pattern_event(slot, pat_num, track, line, column);
            }
        }

        public int sv_get_pattern_lines(int slot, int pat_num)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_pattern_lines(slot, pat_num);
            }
        }

        public IntPtr sv_get_pattern_name(int slot, int pat_num)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_pattern_name(slot, pat_num);
            }
        }

        public int sv_get_pattern_tracks(int slot, int pat_num)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_pattern_tracks(slot, pat_num);
            }
        }

        public int sv_get_pattern_x(int slot, int pat_num)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_pattern_x(slot, pat_num);
            }
        }

        public int sv_get_pattern_y(int slot, int pat_num)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_pattern_y(slot, pat_num);
            }
        }

        public int sv_get_sample_rate()
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_sample_rate();
            }
        }

        public int sv_get_song_bpm(int slot)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_song_bpm(slot);
            }
        }

        public uint sv_get_song_length_frames(int slot)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_song_length_frames(slot);
            }
        }

        public uint sv_get_song_length_lines(int slot)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_song_length_lines(slot);
            }
        }

        public IntPtr sv_get_song_name(int slot)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_song_name(slot);
            }
        }

        public int sv_get_song_tpl(int slot)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_song_tpl(slot);
            }
        }

        public uint sv_get_ticks()
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_ticks();
            }
        }

        public uint sv_get_ticks_per_second()
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_ticks_per_second();
            }
        }

        public int sv_get_time_map(int slot, int start_line, int len, IntPtr dest, int flags)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_get_time_map(slot, start_line, len, dest, flags);
            }
        }

        public int sv_init(IntPtr config, int freq, int channels, uint flags)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_init(config, freq, channels, flags);
            }
        }

        public int sv_load(int slot, IntPtr name)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_load(slot, name);
            }
        }

        public int sv_load_from_memory(int slot, IntPtr data, uint data_size)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_load_from_memory(slot, data, data_size);
            }
        }

        public int sv_load_module(int slot, IntPtr file_name, int x, int y, int z)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_load_module(slot, file_name, x, y, z);
            }
        }

        public int sv_load_module_from_memory(int slot, IntPtr data, uint data_size, int x, int y, int z)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_load_module_from_memory(slot, data, data_size, x, y, z);
            }
        }

        public int sv_lock_slot(int slot)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_lock_slot(slot);
            }
        }

        public int sv_metamodule_load(int slot, int mod_num, IntPtr file_name)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_metamodule_load(slot, mod_num, file_name);
            }
        }

        public int sv_metamodule_load_from_memory(int slot, int mod_num, IntPtr data, uint data_size)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_metamodule_load_from_memory(slot, mod_num, data, data_size);
            }
        }

        public int sv_module_curve(int slot, int mod_num, int curve_num, IntPtr data, int len, int w)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_module_curve(slot, mod_num, curve_num, data, len, w);
            }
        }

        public int sv_new_module(int slot, IntPtr type, IntPtr name, int x, int y, int z)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_new_module(slot, type, name, x, y, z);
            }
        }

        public int sv_new_pattern(int slot, int clone, int x, int y, int tracks, int lines, int icon_seed, IntPtr name)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_new_pattern(slot, clone, x, y, tracks, lines, icon_seed, name);
            }
        }

        public int sv_open_slot(int slot)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_open_slot(slot);
            }
        }

        public int sv_pattern_mute(int slot, int pat_num, int mute)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_pattern_mute(slot, pat_num, mute);
            }
        }

        public int sv_pause(int slot)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_pause(slot);
            }
        }

        public int sv_play(int slot)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_play(slot);
            }
        }

        public int sv_play_from_beginning(int slot)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_play_from_beginning(slot);
            }
        }

        public int sv_remove_module(int slot, int mod_num)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_remove_module(slot, mod_num);
            }
        }

        public int sv_remove_pattern(int slot, int pat_num)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_remove_pattern(slot, pat_num);
            }
        }

        public int sv_resume(int slot)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_resume(slot);
            }
        }

        public int sv_rewind(int slot, int line_num)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_rewind(slot, line_num);
            }
        }

        public int sv_sampler_load(int slot, int sampler_module, IntPtr file_name, int sample_slot)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_sampler_load(slot, sampler_module, file_name, sample_slot);
            }
        }

        public int sv_sampler_load_from_memory(int slot, int sampler_module, IntPtr data, uint data_size, int sample_slot)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_sampler_load_from_memory(slot, sampler_module, data, data_size, sample_slot);
            }
        }

        public int sv_save(int slot, IntPtr name)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_save(slot, name);
            }
        }

        public int sv_send_event(int slot, int track_num, int note, int vel, int module, int ctl, int ctl_val)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_send_event(slot, track_num, note, vel, module, ctl, ctl_val);
            }
        }

        public int sv_set_autostop(int slot, int autostop)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_set_autostop(slot, autostop);
            }
        }

        public int sv_set_event_t(int slot, int set, int t)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_set_event_t(slot, set, t);
            }
        }

        public int sv_set_module_color(int slot, int mod_num, int color)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_set_module_color(slot, mod_num, color);
            }
        }

        public int sv_set_module_ctl_value(int slot, int mod_num, int ctl_num, int val, int scaled)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_set_module_ctl_value(slot, mod_num, ctl_num, val, scaled);
            }
        }

        public int sv_set_module_finetune(int slot, int mod_num, int finetune)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_set_module_finetune(slot, mod_num, finetune);
            }
        }

        public int sv_set_module_name(int slot, int mod_num, IntPtr name)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_set_module_name(slot, mod_num, name);
            }
        }

        public int sv_set_module_relnote(int slot, int mod_num, int relative_note)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_set_module_relnote(slot, mod_num, relative_note);
            }
        }

        public int sv_set_module_xy(int slot, int mod_num, int x, int y)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_set_module_xy(slot, mod_num, x, y);
            }
        }

        public int sv_set_pattern_event(int slot, int pat_num, int track, int line, int nn, int vv, int mm, int ccee, int xxyy)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_set_pattern_event(slot, pat_num, track, line, nn, vv, mm, ccee, xxyy);
            }
        }

        public int sv_set_pattern_name(int slot, int pat_num, IntPtr name)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_set_pattern_name(slot, pat_num, name);
            }
        }

        public int sv_set_pattern_size(int slot, int pat_num, int tracks, int lines)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_set_pattern_size(slot, pat_num, tracks, lines);
            }
        }

        public int sv_set_pattern_xy(int slot, int pat_num, int x, int y)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_set_pattern_xy(slot, pat_num, x, y);
            }
        }

        public int sv_set_song_name(int slot, IntPtr name)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_set_song_name(slot, name);
            }
        }

        public int sv_stop(int slot)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_stop(slot);
            }
        }

        public int sv_sync_resume(int slot)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_sync_resume(slot);
            }
        }

        public int sv_unlock_slot(int slot)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_unlock_slot(slot);
            }
        }

        public int sv_update_input()
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_update_input();
            }
        }

        public int sv_volume(int slot, int vol)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_volume(slot, vol);
            }
        }

        public int sv_vplayer_load(int slot, int mod_num, IntPtr file_name)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_vplayer_load(slot, mod_num, file_name);
            }
        }

        public int sv_vplayer_load_from_memory(int slot, int mod_num, IntPtr data, uint data_size)
        {
            lock (_lock)
            {
                ThrowIfDestroyed();

                return _instance.sv_vplayer_load_from_memory(slot, mod_num, data, data_size);
            }
        }

        #endregion ISunVoxLib
    }
}
